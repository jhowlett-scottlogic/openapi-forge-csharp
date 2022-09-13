const fs = require("fs");
const shell = require("shelljs");

// Extract cl arguments
const clArgs = process.argv.slice(2);

// Retrieve the path to feature paths from cl arguments of 'npm test', use default value if none given
featurePath = clArgs[0] || "..\\..\\..\\openapi-forge\\features\\\*.feature";

const originalFile = fs.readFileSync("./tests/FeaturesTests/FeaturesTests.csproj", "utf-8");

// Replace file path to .feature files in .csproj file
fs.writeFileSync("./tests/FeaturesTests/FeaturesTests.csproj", originalFile.replace("FEATURE_PATH", featurePath));

shell.exec(`dotnet test ./tests/FeaturesTests/FeaturesTests.csproj`);

// Revert .csproj file back
fs.writeFileSync("./tests/FeaturesTests/FeaturesTests.csproj", originalFile);
