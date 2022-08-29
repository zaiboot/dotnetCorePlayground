CREATE TABLE customer (
  id TEXT PRIMARY KEY NOT NULL,
  username TEXT NOT NULL
);

-- -- 100 customers
INSERT INTO customer(id, username)
SELECT TO_CHAR(c, 'fm000') , 'Customer' || TO_CHAR(c, 'fm000') FROM generate_series(1,100) c
;

CREATE TABLE transactions (
  trx_id serial PRIMARY KEY,
  user_id TEXT NOT NULL,
  debit float NOT NULL,
  tax float NOT NULL
);

-- Generate data for users N customers * N transactions. Now 100 * 100
INSERT INTO transactions(user_id, debit, tax )
SELECT  TO_CHAR(c, 'fm000'), d, tax
FROM  generate_series(1,100) c, generate_series(10,100) d, generate_series(1,10) tax;
