# Blood Pressure Calculator Web Application

This repository contains a web application for calculating a blood pressure category. The project is built using ASP.NET Core Razor Pages and aims to provide a user-friendly interface for individuals wishing to submit their systolic and diastolic measurments in order to retrieve their blood pressure category along with a useful tip.

The published app is available at https://sb-csd-bp.azurewebsites.net/

## Features

- **Blood Pressure Calculation**: Enter systolic and diastolic readings to get categorized results.
- **Tip**: Get a useful Tip relevant to your blood pressure category
- **Accessibility**: Easy to use interface with blood pressure category colour coding styling
- **Responsive Design**: Optimised for mobile and desktop use.

## Project Folder Structure

Project folder structure with selection of relevant file descriptions

```
bp/
├── BPCalculator/                 # Main application code
│   ├── Pages/                    # Razor Pages for the web app
│   │   ├── Index.cshtml          # Main page of the application
│   │   └── Chart.cshtml          # Chart page which contains BP Chart image
│   ├── wwwroot/                  # Static files (CSS, JS, images, etc.)
│   ├── BloodPressure.cs          # Main Application Logic
│   └── TipRepository.cs          # Static repository of health tips
├── BPCalculatorTest/             # Unit test project
│   └── BPCalculatorTest.csproj   # Test project file
├── Infrastructure/               # Infrastructure as code
│   ├── template.bicep            # Azure Bicep template for web app
├── .github/                      # GitHub configuration folder
│   ├── workflows/                # GitHub Actions workflows
│   │   ├── ci-cd.yml             # CI/CD workflow definition
│   │   └── smoketest.yml         # Smoke test workflow definition
├── PerformanceTests/             # K6 performance test scripts
│   └── k6-dev.js                 # Script for local development
│   └── k6-staging.js             # Script for staging environment
├── docs/                         # GitHub Pages website files
│   ├── code-coverage/            # ReportGenerator Sample Code Coverage report
│   ├── dependency-check/         # Dependency Check Sample report
├── README.md                     # Project readme
├── LICENSE                       # MIT License file
└── .gitignore                    # Git ignore file

## Getting Started

Follow the steps below to set up and run the project locally.

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A code editor like [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/).

### Clone the Repository

```bash
git clone https://github.com/salob/bp.git
cd bp
```

### Run the Application

1. Restore dependencies:
   ```bash
   dotnet restore
   ```

2. Build the application:
   ```bash
   dotnet build
   ```

3. Run the application:
   ```bash
   dotnet run --project BPCalculator
   ```

Access the application in your browser at `https://localhost:1979`.

## Running Tests

This project includes unit tests to ensure the accuracy of blood pressure calculations.

Run the tests using the following command:

```bash
dotnet test
```

## Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bugfix:
   ```bash
   git checkout -b feature/your-feature-name
   ```
3. Commit your changes and push the branch:
   ```bash
   git push origin feature/your-feature-name
   ```
4. Open a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Thanks to gclynch for boilerplate code
