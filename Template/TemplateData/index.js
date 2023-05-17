var sdkStatus = 0;
var authStatus = 0;

var player = null;
var lb = null;

function initYaGames() {
    YaGames.init().then((ysdk) => {
        window.ysdk = ysdk;
        sdkStatus = 1;
    }).catch((err) => {
        sdkStatus = 0;
        console.log('Failed to initialize SDK with error:', err);
    });
}

function initPlayer() {
    ysdk.getPlayer().then((_player) => {
        player = _player;
        authStatus = player.getMode() === 'lite' ? 0 : 1;
    }).catch((err) => {
        authStatus = 0;
        console.log('Failed to initialize player with error:', err);
    });
}

function initLeaderboards() {
    ysdk.getLeaderboards().then((_lb) => {
        lb = _lb;
    }).catch((err) => {
        console.log('Failed to initialize leaderboards with error:', err);
    });
}

function getSDKStatus() {
    console.log('SDK status:', sdkStatus);
    return sdkStatus;
}

function getAuthStatus() {
    console.log('Auth status:', authStatus);
    return authStatus;
}

function getDevice() {
    var device = ysdk.deviceInfo.type;
    console.log('Detected device:', device);
    return toUnityString(device);
}

function getLanguage() {
    var language = ysdk.environment.i18n.lang;
    console.log('Detected language:', language);
    return toUnityString(language);
}

function saveData(data) {
    var dataString = UTF8ToString(data);
    var dataObject = JSON.parse(dataString);
    player.setData(dataObject).then(() => {
        gameInstance.SendMessage('YandexSDK', 'OnDataSaved');
        console.log('Data saved.');
    }).catch((err) => {
        console.log('Failed to save data with error:', err);
    });
}

function loadData() {
    player.getData().then(data => {
        var dataString = JSON.stringify(data);
        gameInstance.SendMessage('YandexSDK', 'OnDataLoaded', dataString);
        console.log('Data loaded.');
    }).catch((err) => {
        console.log('Failed to load data with error:', err);
    });
}

function setLeaderboard(id, value) {
    try {
        lb.setLeaderboardScore(UTF8ToString(id), value);
        console.log('Leaderboard updated.');
    } catch (err) {
        console.log('Failed to update leaderboard with error:', err);
    }
}

function showFullscreenAdv() {
    ysdk.adv.showFullscreenAdv({
        callbacks: {
            onOpen: () => {
                gameInstance.SendMessage('YandexSDK', 'OnFullscreenAdvOpened');
                console.log('Fullscreen adv opened.');
            },
            onClose: function (result) {
                gameInstance.SendMessage('YandexSDK', 'OnFullscreenAdvClosed');
                console.log('Fullscreen adv closed with result:', result);
            },
            onError: function (err) {
                gameInstance.SendMessage('YandexSDK', 'OnFullscreenAdvFailed');
                console.log('Fullscreen adv opened with error:', err);
            }
        }
    });
}

function showRewardedAdv(reward) {
    ysdk.adv.showRewardedVideo({
        callbacks: {
            onOpen: () => {
                gameInstance.SendMessage('YandexSDK', 'OnVideoAdvOpened');
                console.log('Video adv opened.');
            },
            onRewarded: () => {
                gameInstance.SendMessage('YandexSDK', 'OnVideoAdvRewarded', reward);
                console.log('Video adv rewarded.');
            },
            onClose: () => {
                gameInstance.SendMessage('YandexSDK', 'OnVideoAdvClosed');
                console.log('Video adv closed.');
            },
            onError: (err) => {
                gameInstance.SendMessage('YandexSDK', 'OnVideoAdvFailed');
                console.log('Video adv opened with error:', err);
            }
        }
    });
}

function toUnityString(value) {
    var bufferSize = lengthBytesUTF8(value) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(value, buffer, bufferSize);
    return buffer;
}