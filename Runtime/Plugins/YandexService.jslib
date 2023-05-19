mergeInto(LibraryManager.library, {

  GetSDKStatus: function () {
    return getSDKStatus();
  },

  GetAuthStatus: function () {
    return getAuthStatus();
  },

  GetDevice: function () {
    var device = getDevice();
    var bufferSize = lengthBytesUTF8(device) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(device, buffer, bufferSize);
    return buffer;
  },

  GetLanguage: function () {
    var language = getLanguage();
    var bufferSize = lengthBytesUTF8(language) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(language, buffer, bufferSize);
    return buffer;
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

});