CREATE TABLE wizards
(
    id                 BIGSERIAL PRIMARY KEY,
    first_name         TEXT   NOT NULL,
    last_name          TEXT   NOT NULL,
    patronymic         TEXT,
    birthdate          TIMESTAMP DEFAULT NOW(),
    city               TEXT   NOT NULL,
    known_magic_skills TEXT[] NOT NULL
)