# Motivation
Learn more about tasks, async/await and its possible usages. Inspired by golang routines, want to dig more and figure out if they are comparable.

## Scenario
Let's assume we have 100+ records on DB. They need to be loaded from database and into memory for a later conversion into xml (I know it is old).

Final xml looks like this:
```xml
<Customers>
  <Customer id="123" name="SomeName">
    <Transactions>
      <Transaction Id="T01">
        <Debit>100</Debit>
        <Tax>10</Tax>
      </Transaction>
      .
      .
      . //N transactions
    </Transactions>
  </Customer>
  .
  .
  . //N transactions
</Customer>
```

and in pgsql we have the following tables:
```sql
CREATE TABLE customer (
  username TEXT,
  id TEXT,
);

CREATE TABLE transactions (
  userid TEXT,
  debit float,
  tax float
);
```

This should suffice for our demo, we will need to load the database using:

* dapper.netcore
* process it to a .net class
* return it using an controller

All from scratch.