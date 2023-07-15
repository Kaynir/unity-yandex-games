const ANONIM_AUTH_MODE = 'lite';
const SDK_OBJECT_NAME = 'YandexSDK';

const DATA_SAVED_CALLBACK = 'OnDataSaved';
const DATA_LOADED_CALLBACK = 'OnDataLoaded';

const ADV_OPENED_CALLBACK = 'OnAdvOpened';
const ADV_CLOSED_CALLBACK = 'OnAdvClosed';
const ADV_FAILED_CALLBACK = 'OnAdvFailed';
const ADV_REWARDED_CALLBACK = 'OnAdvRewarded';

var player = null;
var leaderboard = null;
var systemData = {
    deviceCode: 'desktop',
    languageCode: 'en'
};

YaGames.init().then(_ysdk => {
    window.ysdk = _ysdk;
    initPlayer();
    initLeaderboards();
}).catch(err => {
    console.log('Failed to initialize SDK with error:', err);
});

function initPlayer() {
    ysdk.getPlayer().then(_player => {
        player = _player;
    }).catch(err => {
        console.log('Failed to initialize player with error:', err);
    });
}

function initLeaderboards() {
    ysdk.getLeaderboards().then(_leaderboard => {
        leaderboard = _leaderboard;
    }).catch(err => {
        console.log('Failed to initialize leaderboards with error:', err);
    });
}

function isAuthorized() {
    if (player == null) return false;
    return player.getMode() != ANONIM_AUTH_MODE;
}

function getSystemData() {
    systemData.deviceCode = ysdk.deviceInfo.type;
    systemData.languageCode = ysdk.environment.i18n.lang;
    return JSON.stringify(systemData);
}

function saveData(data) {
    let dataObject = JSON.parse(data);
    player.setData(dataObject).then(() => {
        gameInstance.SendMessage(SDK_OBJECT_NAME, DATA_SAVED_CALLBACK, true);
    }).catch((err) => {
        gameInstance.SendMessage(SDK_OBJECT_NAME, DATA_SAVED_CALLBACK, false);
        console.log('Failed to save data with error:', err);
    });
}

function loadData() {
    player.getData().then(data => {
        let dataString = JSON.stringify(data);
        gameInstance.SendMessage(SDK_OBJECT_NAME, DATA_LOADED_CALLBACK, dataString);
    }).catch((err) => {
        console.log('Failed to load data with error:', err);
    });
}

function setLeaderboardScore(id, value) {
    if (isAuthorized() == false) return;
    leaderboard.setLeaderboardScore(id, value);
}

function showFullscreenAdv() {
    ysdk.adv.showFullscreenAdv({
        callbacks: {
            onOpen: () => {
                gameInstance.SendMessage(SDK_OBJECT_NAME, ADV_OPENED_CALLBACK);
            },
            onClose: function (result) {
                gameInstance.SendMessage(SDK_OBJECT_NAME, ADV_CLOSED_CALLBACK);
                console.log('Fullscreen adv closed with result:', result);
            },
            onError: function (err) {
                gameInstance.SendMessage(SDK_OBJECT_NAME, ADV_FAILED_CALLBACK);
                console.log('Fullscreen adv opened with error:', err);
            }
        }
    });
}

function showRewardedAdv(reward) {
    ysdk.adv.showRewardedVideo({
        callbacks: {
            onOpen: () => {
                gameInstance.SendMessage(SDK_OBJECT_NAME, ADV_OPENED_CALLBACK);
            },
            onRewarded: () => {
                gameInstance.SendMessage(SDK_OBJECT_NAME, ADV_REWARDED_CALLBACK, reward);
            },
            onClose: () => {
                gameInstance.SendMessage(SDK_OBJECT_NAME, ADV_CLOSED_CALLBACK);
            },
            onError: (err) => {
                gameInstance.SendMessage(SDK_OBJECT_NAME, ADV_FAILED_CALLBACK);
                console.log('Video adv opened with error:', err);
            }
        }
    });
}