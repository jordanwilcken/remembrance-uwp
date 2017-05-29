var remembrance = remembrance || {};

(function () {
  'use strict';

  remembrance.appConfig = {

    //Returns a promise because the UWP API, like so many things nowadays,
    //is all about the async.
    initializeDatabase: function () {
      return new persistence_component.Startup()
        .initializeDatabase();
      }
    }
}());