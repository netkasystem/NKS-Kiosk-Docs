var app = angular.module('main', []);

app.directive("select2", ["$timeout", function ($timeout) {
    return {
        restrict: "A",
        require: "ngModel",
        scope: {
            config: "=?",
            preSelected: "=?",
            modelValue: "=ngModel",
            refresh: "=?",
            select2Name: "@?",
            select2Filter: "=?filter",
            select2Data: "=?",
            select2Default: "=?",
            select2DefaultEmpty: "@?defaultEmpty",
            ngHide: "=?ngHide",
            ngShow: "=?ngShow",
        },
        link: function (scope, element, attrs, ngModelCtrl) {
            var IsMultiple = $(element).attr('multiple');
            var IsZeroIndex = $(element).attr('zeroindex') != null;
            var Tags = $(element).attr('tags') || $(element).attr('tags') == "";
            var NgModelName = $(element).attr('ng-model');
            scope.config = scope.config || {};

            $timeout(function () {
                //console.log(NgModelName, " scope.select2DefaultEmpty ", scope.select2DefaultEmpty);
                if (!scope.select2Default) {
                    if (IsZeroIndex) scope.select2Default = { id: -1, text: "--- Please select ---" };
                    if (!IsZeroIndex) scope.select2Default = { id: 0, text: "--- Please select ---" };
                }
                if (scope.select2DefaultEmpty) scope.select2Default = null;

                if (!scope.select2Name && !scope.config?.ajax) {
                    scope.s2 = element.select2(scope.config);
                    return false;
                } else {
                    InitSelect2();
                }
            });

            function getDropdownParent() {
                var dropdownParent = $(document.body);
                if (element.parents(".modal").length !== 0) dropdownParent = element.parents(".modal");
                return dropdownParent;
            }

            function InitSelect2() {
                //console.log(NgModelName, " select2 InitSelect2 ======> ");
                scope.config.dropdownParent = getDropdownParent();
                scope.config.preSelected = PreSelect;
                scope.config.recreateSelect = RecreateSelect;
                scope.config.setDefault = () => PreSelect(scope.select2Default);
                scope.config.findFirst = FindFirst;
                scope.config.setFirst = SetFirst;
                scope.config.setFirstAsync = SetFirstAsync;
                scope.config.FindDetail = FindDetail;
                scope.config.templateResult = scope.config.templateResult || function (res) { return res?.template_result ? $(res?.template_result) : res.text };
                scope.config.templateSelection = scope.config.templateSelection || function (res) { return res?.template_selection ? $(res?.template_selection) : res.text };

                if (Tags) scope.config.tags = Tags;

                if (scope?.config?.ajax) scope.config.ajax.delay = 800;
                if (scope.select2Name) {
                    scope.config.ajax = {
                        delay: 800,
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        url: "/api/Select2Api/SearchData",
                        dataType: "json",
                        cors: true,
                        cache: true,
                        data: function (params) {
                            var query = {
                                Select2Name: scope.select2Name,
                                Filter: scope.select2Filter ?? {},
                                search: { value: params.term || "" },
                                start: params.page * 20 || 0,
                                length: 20,
                            };
                            return JSON.stringify(query);
                        },
                        processResults: function (data, params) {
                            if (Tags) {
                                var ls_all_tags = JSON.parse(data.items[0]?.items);
                                //check duplicate
                                var ls_uniq_tags = [...new Set(ls_all_tags)];
                                data.items = ls_uniq_tags?.map(x => ({ id: x, text: x })) || [];
                                data.total_count = data.items[0]?.total_count || 0;
                            }

                            params.page = params.page || 0;
                            scope.config.total_count = data.total_count;
                            var more = params.page * 20 < data.total_count && data.items.length < data.total_count;
                            if (params.page == 0 && scope.select2Default && !IsMultiple && !data.items.some(x => ((x.id == -1 || x.id == "-1") && IsZeroIndex) || (x.id == 0 || x.id == "0") && !IsZeroIndex))
                                data.items = [scope.select2Default].concat(data.items);
                            return {
                                results: data.items,
                                pagination: { more: more },
                            };
                        },
                    };
                }

                scope.s2 = element.select2(scope.config);
                PreSelect((!scope.config.ajax && scope.modelValue) || scope.config.defaultValue || scope.select2Default);
                HideArrow();
                scope.StoreDataSelect = [];

                scope.s2.on("select2:selecting", function (e) { if (scope.config?.OnSelected) scope.config.OnSelected(e); });
                scope.s2.on("select2:select", function (e) { scope.StoreDataSelect.push(e.params.data); Select2Change(); })
                scope.s2.on("select2:unselect", function (e) { Select2Change(); });
                scope.s2.on("select2:open", scope.config.OnOpen || function (e) { });
                scope.s2.on("select2:closing", scope.config.OnCloseing || function (e) { scope.config.total_count = 0; });
            }

            function Select2Change() {
                scope.config.defaultValue = scope.s2.select2("data");

                if (!IsMultiple) {
                    scope.select2Data = scope.StoreDataSelect.slice(-1)[0];
                    if (scope.config.ChangeSelect) scope.config.ChangeSelect(scope.select2Data);
                }
                else if (IsMultiple) {
                    scope.StoreDataSelect = [...new Set(scope.StoreDataSelect)];
                    scope.StoreDataSelect = scope.StoreDataSelect.filter(x => scope.s2.select2("data").find(d => d.id == x.id));
                    scope.select2Data = scope.StoreDataSelect;
                    if (scope.config.ChangeSelect) scope.config.ChangeSelect(scope.StoreDataSelect);
                }
            }

            function HideArrow() { if (scope.config?.allowClear) element.next().find('span[role="presentation"]').remove(); }

            function RecreateSelect() {
                //console.log("RecreateSelect");
                if (element?.data('select2')) { element?.select2('destroy'); }
                $timeout(() => { InitSelect2(); }, 200);
            }

            function PreSelect(data, selected = true) {
                //console.log(NgModelName, " - PreSelect => ", data);
                if (!scope?.s2) return false;
                $timeout(function () {
                    if (!data) data = scope.select2Default;
                    if (data != null && !Array.isArray(data) && typeof data == "object") data = [data];
                    if (Array.isArray(data)) data = data.filter(x => x != null || x != "null");
                    if (IsMultiple && typeof data == "string") data = data.split(",");

                    if (!data?.length) { if (IsMultiple) data = []; else data = [scope.select2Default]; }

                    if (scope?.config?.ajax) scope.s2.empty();
                    if (data?.length) {
                        data = data.map((x) => ({ id: x.id ?? x, text: x.text ?? x }));
                        var select_val = data.map(x => x.id);

                        //filter add option and additional data
                        var add_data = data;

                        //filter please select
                        if (IsMultiple) { add_data = add_data.filter(x => !(x.id == scope.select2Default.id && x.text == scope.select2Default.text)); }
                        //filter duplicate data
                        add_data = add_data.filter(x => !element.find("option[value='" + x.id + "']").length);
                        if (element.data('select2')) {
                            add_data = add_data.filter(x => !scope.s2.select2("data").find(_d => _d.id == x.id && x.text == _d.text));
                        }
                        add_data = add_data.filter((v, i, a) => a.findIndex((v2) => v2.id === v.id) === i);
                        add_data.forEach((x) => scope.s2.append(new Option(x.text, x.id, true, selected)));

                        //select option
                        if (selected) scope.s2.val(select_val).trigger("change");
                        else scope.s2.trigger("change");
                    } else {
                        scope.s2.val(null).trigger("change");
                    }
                });
            }

            function FindFirstAsync(_d = {}, _cb = null, time = 300) {
                $timeout.cancel(scope.hasFindFirst);
                return new Promise((resolve, reject) => {
                    scope.hasFindFirst = $timeout(async () => {
                        //console.log(NgModelName, "- FindFirst -");
                        var Filter = { ...(scope.select2Filter ?? {}), ..._d };
                        var _param = { Select2Name: scope.select2Name, Filter, start: 0 };
                        if (!IsMultiple) _param["length"] = 1;
                        if (_d["SetFirst"]) _param["SetFirst"] = _d["SetFirst"];

                        var data = JSON.stringify(_param);
                        var _call = { ...scope.config.ajax, data };

                        try {
                            var res = await $.ajax(_call);
                            if (res?.items?.length > 0) {
                                PreSelect(res?.items);
                            } else {
                                PreSelect([scope.select2Default]);
                            }
                            if (_cb) _cb(res?.items);
                            resolve(res?.items);
                        } catch (error) {
                            reject(error);
                        }
                    }, time);
                });
            }

            function SetFirstAsync(_d, _cb = null) {
                //console.log(NgModelName, "- SetFirst -");
                var Filter = {};
                if (!_d || _d == "" || ((_d == "0" && !IsZeroIndex) || (_d == "-1" && IsZeroIndex))) return Promise.resolve(false);
                else if (typeof _d == "string" || typeof _d == "number") {
                    Filter["SetFirstID"] = IsMultiple ? _d.split(",") : _d;
                }
                else if (IsMultiple && Array.isArray(_d)) {
                    Filter["SetFirstID"] = _d;
                }
                else {
                    var _filter_data = IsZeroIndex ? Object.entries(_d) : Object.entries(_d).filter(x => x[1] && x[1] != "");
                    if (!_filter_data?.length) {
                        PreSelect([]);
                        return Promise.resolve(false);
                    }
                    if (IsMultiple) {
                        _d = Object.fromEntries(_filter_data.map(x => {
                            if ('string' == typeof x[1]) { x[1] = x[1].split(","); }
                            return x;
                        }));
                    }
                    Filter["SetFirst"] = { ..._d };
                }
                return FindFirstAsync(Filter, _cb);
            }

            function FindFirst(_d = {}, _cb = null, time = 300) {
                $timeout.cancel(scope.hasFindFirst);
                scope.hasFindFirst = $timeout(async () => {
                    //console.log(NgModelName, "- FindFirst -");
                    var Filter = { ...(scope.select2Filter ?? {}), ..._d };
                    var _param = { Select2Name: scope.select2Name, Filter, start: 0 };
                    if (!IsMultiple) _param["length"] = 1;
                    if (_d["SetFirst"]) _param["SetFirst"] = _d["SetFirst"];

                    var data = JSON.stringify(_param);
                    var _call = { ...scope.config.ajax, data };

                    var res = await $.ajax(_call);
                    if (res?.items?.length > 0) { PreSelect(res?.items); }
                    else { PreSelect([scope.select2Default]); }
                    if (_cb) _cb(res?.items);
                }, time);
            };

            function SetFirst(_d, _cb = null) {
                //console.log(NgModelName, "- SetFirst -");
                var Filter = {};
                if (!_d || _d == "" || ((_d == "0" && !IsZeroIndex) || (_d == "-1" && IsZeroIndex))) return false;
                else if (typeof _d == "string" || typeof _d == "number") { Filter["SetFirstID"] = IsMultiple ? _d.split(",") : _d; }
                else if (IsMultiple && Array.isArray(_d)) { Filter["SetFirstID"] = _d; }
                else {
                    var _filter_data = IsZeroIndex ? Object.entries(_d) : Object.entries(_d).filter(x => x[1] && x[1] != "");
                    if (!_filter_data?.length) { PreSelect([]); return false; }
                    if (IsMultiple) { _d = Object.fromEntries(_filter_data.map(x => { if ('string' == typeof x[1]) { x[1] = x[1].split(","); } return x; })); }
                    Filter["SetFirst"] = { ..._d };
                }
                return FindFirst(Filter, _cb);
            };

            function FindDetail(_d = {}, _cb = null, time = 700) {
                $timeout.cancel(scope.hasFindDetail);
                scope.hasFindDetail = $timeout(async () => {
                    //console.log(NgModelName, "- FindDetail -");
                    var Filter = { ...(scope.select2Filter ?? {}), ..._d };
                    var _param = { Select2Name: scope.select2Name, Filter, start: 0, length: 10, ..._d };

                    var data = JSON.stringify(_param);
                    var _call = { ...scope.config.ajax, data };
                    var res = await $.ajax(_call);
                    if (_cb) _cb(res?.items);
                }, time);
            };

            scope.refresh = RecreateSelect;
            scope.preSelected = PreSelect;
            scope.$watch("config", RecreateSelect);
            scope.$watch("config.data", (d) => { PreSelect([scope.select2Default].concat(d), false); });
            scope.$watch("config.tags", (d) => { RecreateSelect(d); });
            scope.$watch("config.defaultValue", (_new, _old) => { PreSelect(_new); });
            scope.$watch('ngHide', function (d) { if (d || d == '0') element.next(".select2-container").hide(); else element.next(".select2-container").show(); });
            scope.$watch('ngShow', function (d) { if (d || d == '0') element.next(".select2-container").show(); else element.next(".select2-container").hide(); });
        }
    };
}]);