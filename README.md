# CPSC1012 Advanced Portfolio – Fall 2018 Term

# Username & Password Authentication

This is username and password verifier written in ``C#`` with object oriented programming. It helps system administrators while creating user accounts.
The userAccount Class contains:
  - A `string` property named **Username** of the account (default user1).
  - A `string` property named **Password** of the account (default P@ssword1).
  - A no-argument constructor that creates a default UserAccount.
  - A constructor that creates a UserAccount with the specified username and password.
  - The mutator for **Username** will check if the new value matches the username criteria before using the new value.
  - The mutator for **Password** will check if the new value matches the password criteria before using the new value.

For instance you are a system administrator for the company responsible for creating user accounts for employees. The company requires that username and password meet the following criteria:

- The username is case insensitive, between 3 to 15 characters, and contain only alphanumeric characters (letters A-Z, numbers 0-9) and the underscore character (_).

- The password is case sensitive, it must not contain your username, and contain the following:

  - Between 8 to 80 characters long (no spaces)
  
  - At least one upper case character (A-Z)
  
  - At least one lower case character (a-z)
  
  - At least one number (0-9)
  
  - At least one special character (!@#$%^*_=+.?-)
  
  ## Output Testing
```
***********************
* New Account Details *
***********************
Enter the username: j
Invalid username format! The username must between 3 to 15 characters.
Enter the username: j@nait.ca
Invalid username format! The username may use only the characters: Aa-Zz, 0-9, -_
Enter the username: jw1
Enter the password: password
Invalid password format! The password must contain at least one lowercase letter, one uppercase letter, one digit, and one special character (! @ # $ % ^ * _ = + . ? -).
Enter the password: passwordJW1123
Invalid password format! The password cannot contain your username
Enter the password: passwordJW 123
Invalid password format! The password cannot contain spaces
Enter the password passwordJW!23
The following account information has been successfully created.
Username: jw1, Password: passwordJW!23

```

