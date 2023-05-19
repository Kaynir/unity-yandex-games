mergeInto(LibraryManager.library, {

  GetSDKStatus: function () {
    return getSDKStatus();
  },

  GetAuthStatus: function () {
    return getAuthStatus();
  },

  GetDevice: function () {
    var device = getDevice();
    return GetUnityString(device);
  },

  GetLanguage: function () {
    var language = getLanguage();
    return GetUnityString(language);
  },

  SaveData: function (data) {
    saveData(UTF8ToString(data));
  },

  LoadData: function () {
    loadData();
  },

  SetLeaderboard: function (id, value) {
    setLeaderboard(UTF8ToString(id), value);
  },

  ShowFullscreenAdv: function () {
    showFullscreenAdv();
  },

  ShowRewardedAdv: function (reward) {
    showRewardedAdv(reward);
  },

  GetUnityString: function (value) {
    var bufferSize = lengthBytesUTF8(value) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(value, buffer, bufferSize);
    return buffer;
  },

});