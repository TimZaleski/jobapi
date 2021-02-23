USE jobapitimz;

CREATE TABLE contractors
(
  id INT AUTO_INCREMENT,
  name VARCHAR(255),

  PRIMARY KEY (id)
);

CREATE TABLE jobs
(
  id INT AUTO_INCREMENT,
  title VARCHAR(255),
  rate DECIMAL(6,2),

  PRIMARY KEY (id)
);

-- TRUNCATE TABLE kits;
-- TRUNCATE TABLE bricks;


CREATE TABLE jobcontractors
(
  id INT AUTO_INCREMENT,
  jobId INT,
  contractorId INT,

  PRIMARY KEY (id),

  FOREIGN KEY (jobId)
    REFERENCES jobs(id)
    ON DELETE CASCADE,

  FOREIGN KEY (contractorId)
    REFERENCES contractors(id)
    ON DELETE CASCADE
);