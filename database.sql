CREATE TABLE Vector (
    token int NOT NULL,
    word varchar(255) NOT NULL,
    PRIMARY KEY (token)
);

CREATE TABLE Definition (
    id int NOT NULL,
    vectorLink int NOT NULL,
    PRIMARY KEY (id),
    CONSTRAINT definitionToVector FOREIGN KEY (vectorLink) REFERENCES Vector(token)
);

CREATE TABLE Related (
    id int IDENTITY(1,1),
    definitionID int NOT NULL,
    relatedVector int NOT NULL,
    PRIMARY KEY (id),
    CONSTRAINT relatedToDefinition FOREIGN KEY (definitionID) REFERENCES Definition(id),
    CONSTRAINT relatedToVector FOREIGN KEY (relatedVector) REFERENCES Vector(token)
);