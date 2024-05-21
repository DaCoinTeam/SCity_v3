mergeInto(LibraryManager.library, {
  HandleConnectSuietButtonClick: function () {
    return window.dispatchReactUnityEvent("HandleConnectSuietButtonClick");
  },
  HandleSignInWithGoogleButtonClick: function () {
    return window.dispatchReactUnityEvent("HandleSignInWithGoogleButtonClick");
  },
  HandleSignInWithFacebookButtonClick: function () {
    return window.dispatchReactUnityEvent("HandleSignInWithFacebookButtonClick");
  },
}); 