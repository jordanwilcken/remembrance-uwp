var remembrance = remembrance || {};

(function () {
  'use strict';

  remembrance.RemembranceApp = RemembranceApp;

  function RemembranceApp(containerElement, appConfig) {
    var
      _currentUser = remembrance.auth.noneUser;

    this.start = function () {
      appConfig.setTheSettings();
      appConfig.initializeDatabase()
        .then(function () {
          loginAsGuest();
          document.getElementById("username-display").innerHTML = _currentUser.name;
          //initializeChildApps();
        });
    };

    function loginAsGuest() {
      _currentUser = new persistence_component.UsersRepo(new persistence_component.SQLiteConnectionMaker())
        .get(remembrance.auth.guestName);
    }

    function initializeChildApps() {
      //HERES WHERE TO START
      //recordList = new listApp.App(recordListContainer, remembrance.appConfig),
      //  editRecord = new editRecordApp.App(editRecordContainer, remembrance.appConfig);

      //initialize_ioc_container();

      //configureViews(recordList, editRecord);
    }

    //function setCurrentUser(user) {
    //  Object.defineProperty(this, 'currentUser', { get: function () { return user; } });
    //}
  }
}());