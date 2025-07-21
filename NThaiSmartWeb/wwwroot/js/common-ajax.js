const ajaxCommon = {
    showLoading: function () {
        $("#loading").show();
    },
    hideLoading: function () {
        $("#loading").hide();
    },

    get: function (url, successCallback, errorCallback) {
        this.showLoading();
        $.ajax({
            url: url,
            method: "GET",
            success: function (data) {
                successCallback && successCallback(data);
            },
            error: function (xhr, status, error) {
                errorCallback && errorCallback(xhr, status, error);
            },
            complete: () => this.hideLoading()
        });
    },

    post: function (url, data, successCallback, errorCallback) {
        this.showLoading();
        $.ajax({
            url: url,
            method: "POST",
            contentType: "application/json",
            data: JSON.stringify(data),
            success: function (data) {
                successCallback && successCallback(data);
            },
            error: function (xhr, status, error) {
                errorCallback && errorCallback(xhr, status, error);
            },
            complete: () => this.hideLoading()
        });
    },

    put: function (url, data, successCallback, errorCallback) {
        this.showLoading();
        $.ajax({
            url: url,
            method: "PUT",
            contentType: "application/json",
            data: JSON.stringify(data),
            success: function (data) {
                successCallback && successCallback(data);
            },
            error: function (xhr, status, error) {
                errorCallback && errorCallback(xhr, status, error);
            },
            complete: () => this.hideLoading()
        });
    },

    delete: function (url, successCallback, errorCallback) {
        this.showLoading();
        $.ajax({
            url: url,
            method: "DELETE",
            success: function (data) {
                successCallback && successCallback(data);
            },
            error: function (xhr, status, error) {
                errorCallback && errorCallback(xhr, status, error);
            },
            complete: () => this.hideLoading()
        });
    }
};