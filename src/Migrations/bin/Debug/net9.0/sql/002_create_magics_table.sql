CREATE TABLE magics
(
    id               uuid PRIMARY KEY,
    wizard_id        BIGINT NOT NULL,
    salary           BIGINT NOT NULL,
    experience_years INT    NOT NULL,
    desired_skill    TEXT   NOT NULL,
    status           INT    NOT NULL,
    created_at       TIMESTAMP DEFAULT NOW(),

    CONSTRAINT to_wizard FOREIGN KEY (wizard_id) REFERENCES wizards (id)
        ON DELETE CASCADE
        ON UPDATE CASCADE
)