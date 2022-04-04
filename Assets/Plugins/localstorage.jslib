mergeInto(LibraryManager.library, {
  SaveHighscore: function (score) {
    window.localStorage.setItem("highscore", score);
  },
  GetHighscore: function () {
    window.localStorage.getItem("highscore")
  }
});