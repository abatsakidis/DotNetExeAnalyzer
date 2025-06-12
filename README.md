# DotNetExeAnalyzer

![Build Status](https://github.com/abatsakidis/DotNetExeAnalyzer/actions/workflows/dotnet.yml/badge.svg)

DotNetExeAnalyzer is a simple WPF application for inspecting .NET executable (.exe) and library (.dll) files. It uses Mono.Cecil to load assemblies and display their types, methods, and Intermediate Language (IL) instructions.

## Features

- Open and analyze .NET assemblies (.exe, .dll)
- View assembly metadata including name, version, and runtime
- Browse all types and methods in a tree view
- Display IL instructions for selected methods
- Filter types and methods by search text
- Copy IL code to clipboard
- Export IL code to a text file

## Requirements

- Windows OS
- .NET Framework or .NET Core supporting WPF
- Mono.Cecil library
- MahApps.Metro for modern UI styling

## Usage

1. Click **Open File** to select a .NET executable or DLL.
2. Explore the types and their methods in the tree view.
3. Select a method to view its IL code.
4. Use the search box to filter displayed types and methods.
5. Copy or export IL code as needed.

## Notes

- The search box supports filtering by type or method name.
- Methods without a body will not display IL code.
- The UI uses MahApps.Metro for better visuals.

## License

MIT License


