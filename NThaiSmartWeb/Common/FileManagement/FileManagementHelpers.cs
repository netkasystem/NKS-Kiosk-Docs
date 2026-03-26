public static class FileManagementHelpers
{
    private static readonly HttpClient _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(60) };

    /// <summary>
    /// Get file storage API URL from FILE_STORAGE_URL env var.
    /// When set, files are uploaded via HTTP PUT instead of local disk.
    /// </summary>
    public static string GetFileStorageUrl() => Environment.GetEnvironmentVariable("FILE_STORAGE_URL");

    public static string SaveFilePath(FileViewModel item, string des, string subPath = "file")
    {
        string base64 = item.FileBase64;

        subPath = (subPath ?? "file").Replace("\\", "/").Trim('/');

        if (base64.StartsWith("data:"))
        {
            var header = base64.Substring(5, base64.IndexOf(';') - 5); // image/png
            base64 = base64.Substring(base64.IndexOf(",") + 1);
        }

        var bytes = Convert.FromBase64String(base64);

        var now = DateTime.Now;
        var ext = Path.GetExtension(item.FileName);
        var fileName = $"{DateTimeOffset.Now.ToUnixTimeMilliseconds()}{ext}";
        var relativePath = $"/uploads/{subPath}/{now.Year}/{now.Month:00}/{fileName}";

        var storageUrl = GetFileStorageUrl();
        if (!string.IsNullOrEmpty(storageUrl))
        {
            // Upload via HTTP PUT to file storage server (base URL + /api/files/)
            var uploadUrl = storageUrl.TrimEnd('/') + $"/api/files/{subPath}/{now.Year}/{now.Month:00}/{fileName}";
            var response = _httpClient.PutAsync(uploadUrl, new ByteArrayContent(bytes)).Result;
            response.EnsureSuccessStatusCode();
        }
        else
        {
            // Save to local disk (single server or dev)
            string rootPath = Environment.GetEnvironmentVariable("UPLOAD_ROOT_PATH")
                ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
            var folder = Path.Combine(rootPath, subPath, now.Year.ToString(), now.Month.ToString("00"));
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            File.WriteAllBytes(Path.Combine(folder, fileName), bytes);
        }

        return relativePath;
    }

    public static bool RemoveFilePath(string relativePath, string des)
    {
        try
        {
            if (string.IsNullOrEmpty(relativePath))
                return false;

            var storageUrl = GetFileStorageUrl();
            if (!string.IsNullOrEmpty(storageUrl))
            {
                // Delete via HTTP DELETE to file storage server (base URL + /api/files/)
                // /uploads/asset/2026/03/file.jpg → /api/files/asset/2026/03/file.jpg
                var filePath = relativePath.TrimStart('/');
                if (filePath.StartsWith("uploads/"))
                    filePath = filePath.Substring("uploads/".Length);
                var deleteUrl = storageUrl.TrimEnd('/') + "/api/files/" + filePath;
                var response = _httpClient.DeleteAsync(deleteUrl).Result;

                return response.IsSuccessStatusCode;
            }
            else
            {
                // Delete from local disk
                string uploadRoot = Environment.GetEnvironmentVariable("UPLOAD_ROOT_PATH");
                string rootPath = uploadRoot != null ? Path.GetFullPath(Path.Combine(uploadRoot, "..")) : Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

                relativePath = relativePath.TrimStart('/');
                var fullPath = Path.Combine(rootPath, relativePath);

                if (File.Exists(fullPath))
                {
                    var fileInfo = new FileInfo(fullPath);
                    var FileSize = (ulong)fileInfo?.Length;

                    File.Delete(fullPath);

                    return true;
                }
            }
        }
        catch (Exception ex)
        {
        }
        return false;
    }
}