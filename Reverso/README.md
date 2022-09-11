<a name="readme-top"></a>

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">Reverso</a>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>



## Reverso

Reverso will reverse your words. It will reverse them so hard.
This is only the backend parts meaning word reversal 

How it reverses words:
* Words are delineated with space. This behavior cannot be changed. Every word will be reversed separately but will keep its ordering in the string.
* Special characters will be reversed along with letters unless you place them in the "ImmovableCharacters" setting in appsettings.json. Then they will be treated as a space.
* Inputs exceeding MaxInputStringLength will throw a 400.


## Getting Started

### Prerequisites

Set up a LocalDB SQL Express on your machine. https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver16

### Installation

1. Clone the repo and open it in your favourite IDE
2. Make sure the DB connection string in appsettings.json looks like this: Data Source=.\\sqlexpress;Initial Catalog=Reverso;Integrated Security=True;TrustServerCertificate=True
3. Build the solution
4. Run the solution by either a) running it through your favourite IDE and use live hosting (such as IIS Express) or b) copy the build files into a folder and host it on your favourite web server-express-localdb
5. Visit the hosted address and enjoy!

<p align="right">(<a href="#readme-top">back to top</a>)</p>


## License

This software is free to use. No license needed. Reverse away!



## Contact

You already know who I am!


