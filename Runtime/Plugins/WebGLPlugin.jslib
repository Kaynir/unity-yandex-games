mergeInto(LibraryManager.library, {

  JavaToUnityString: function (javaString) {
    var bufferSize = lengthBytesUTF8(javaString) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(javaString, buffer, bufferSize);
    return buffer;
  },

  UnityToJavaString: function (unityString) {
    return UTF8ToString(unityString);
  },

});