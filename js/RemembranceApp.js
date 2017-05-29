var remembrance = remembrance || {};

(function () {
  'use strict';

  remembrance.RemembranceApp = RemembranceApp;

  function RemembranceApp(containerElement, appConfig) {


    this.start = function () {
      appConfig.initializeDatabase()
        .then(function (val) {
          console.log(val);
        });
      //SHOULD have a then right here because initializeDatabase will return a promise

      //setCurrentUser to none
      //appConfig.getCurrentUser(setCurrentUser);
    };

    //function setCurrentUser(user) {
    //  Object.defineProperty(this, 'currentUser', { get: function () { return user; } });
    //}
  }
}());