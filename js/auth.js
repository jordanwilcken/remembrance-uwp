var remembrance = remembrance || {};
remembrance.auth = remembrance.auth || {};

(function () {
  'use strict';

  remembrance.auth.noneUser = new remembrance.models.User("None");
  remembrance.auth.guestName = "Guest";
}());