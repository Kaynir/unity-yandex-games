var container = document.querySelector("#unity-container");
var canvas = document.querySelector("#unity-canvas");
var loadingBar = document.querySelector("#unity-loading-bar");
var progressBarFull = document.querySelector("#unity-progress-bar-full");

var buildUrl = "Build";
var loaderUrl = buildUrl + "/{{{ LOADER_FILENAME }}}";
var config = {
    dataUrl: buildUrl + "/{{{ DATA_FILENAME }}}",
    frameworkUrl: buildUrl + "/{{{ FRAMEWORK_FILENAME }}}",
#if USE_WASM
    codeUrl: buildUrl + "/{{{ CODE_FILENAME }}}",
#endif
#if MEMORY_FILENAME
    memoryUrl: buildUrl + "/{{{ MEMORY_FILENAME }}}",
#endif
#if SYMBOLS_FILENAME
    symbolsUrl: buildUrl + "/{{{ SYMBOLS_FILENAME }}}",
#endif
    streamingAssetsUrl: "StreamingAssets",
    companyName: {{{ JSON.stringify(COMPANY_NAME) }}},
    productName: {{{ JSON.stringify(PRODUCT_NAME) }}},
    productVersion: {{{ JSON.stringify(PRODUCT_VERSION) }}}
};

loadingBar.style.display = "block";

var script = document.createElement("script");
var gameInstance = null;

script.src = loaderUrl;
script.onload = () => {
    createUnityInstance(canvas, config, (progress) => {
        progressBarFull.style.width = 100 * progress + "%";
    }).then((unityInstance) => {
        gameInstance = unityInstance;
        loadingBar.style.display = "none";
    }).catch((message) => {
        alert(message);
    });
};

document.body.appendChild(script);