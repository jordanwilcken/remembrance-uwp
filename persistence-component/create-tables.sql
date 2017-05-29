CREATE TABLE users (
  username TEXT UNIQUE NOT NULL CHECK(length(username) > 0),
  hashed_password TEXT NOT NULL CHECK(length(hashed_password) > 0)
);

INSERT INTO users (rowid, username, hashed_password) VALUES (1, 'Guest', 'password');

CREATE TABLE records (
  guid TEXT NOT NULL PRIMARY KEY CHECK(length(guid) = 36),
  name TEXT NOT NULL CHECK(length(name) > 0)
);

CREATE TABLE user_record (
  username TEXT NOT NULL,
  record_guid TEXT NOT NULL,
  FOREIGN KEY(username) REFERENCES users(username),
  FOREIGN KEY(record_guid) REFERENCES records(guid),
  CONSTRAINT pk_user_record PRIMARY KEY (username, record_guid)
);

CREATE TABLE record_versions (
	record_guid TEXT REFERENCES records(guid),
	creation_date INTEGER NOT NULL,
	version_content BLOB NOT NULL CHECK(length(version_content) > 0),
	CONSTRAINT pk_record_versions PRIMARY KEY (record_guid, creation_date)
);