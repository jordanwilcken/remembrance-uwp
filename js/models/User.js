var remembrance = remembrance || {};
remembrance.models = remembrance.models || {};

(function () {
  'use strict';

  remembrance.models.User = User;

  function User(username) {
    Object.defineProperty(this, 'name', { get: function () { return username; } });
  }
}());