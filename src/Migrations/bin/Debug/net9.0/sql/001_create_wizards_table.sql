CREATE TABLE Wizards
(
    id                 BIGSERIAL PRIMARY KEY,
    first_name         TEXT   NOT NULL,
    last_name          TEXT   NOT NULL,
    patronymic         TEXT,
    birthdate          TIMESTAMP,
    city               TEXT   NOT NULL,
    known_magic_skills TEXT[] NOT NULL
)