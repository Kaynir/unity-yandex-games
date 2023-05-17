mergeInto(LibraryManager.library, {

  GetSDKStatus: function () {
    return getSDKStatus();
  },

  GetAuthStatus: function () {
    return getAuthStatus();
  },

  GetDevice: function () {
    return getDevice();
  },

  GetLanguage: function () {
    return getLanguage();
  },

  SaveData: function (data) {
    saveData(data);
  },

  LoadData: function () {
    loadData();
  },

  SetLeaderboard: function (id, value) {
    setLeaderboard(id, value);
  },

  ShowFullscreenAdv: function () {
    showFullscreenAdv();
  },

  ShowRewardedAdv: function (reward) {
    showRewardedAdv(reward);
  },

});