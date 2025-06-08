# FamilyTree

FamilyTree is a Windows Forms (WinForms) application built in C# that visualizes family trees as interactive pedigree charts. It displays family relationships with names, genders, and connections, rendered in a 1920x1080 window with scrolling support for large trees. The project includes a complex 5-generation family tree with Western names for testing, supporting features like multiple marriages, single individuals, and varied family sizes.

This project is developed using Visual Studio Code (VSCode) and is licensed under the [MIT License](LICENSE).

## Background

FamilyTree was created as part of the [Weekly Programming Challenge #12](https://weblog.jamisbuck.org/2016/10/15/weekly-programming-challenge-12.html), posted on October 15, 2016, by Jamis Buck. The challenge’s normal mode required constructing and rendering a pedigree chart for at least four generations, displaying names in a traditional left-to-right tree format. This project builds on that challenge, implementing a five-generation pedigree chart with a complex family structure, efficient rendering, and interactive scrolling to handle large trees. Additional features, such as double-buffered rendering and customizable scaling, enhance the challenge’s requirements for a robust visualization tool.

## Features
- **Family Tree Visualization**: Renders family trees with names (blue for offspring, red for spouses) and connecting lines.
- **Scrolling Support**: Handles large trees with horizontal and vertical scrolling via mouse wheel, scrollbars, or drag-to-scroll (if implemented).
- **Complex Tree Support**: Includes a 5-generation test tree (~60 individuals) with remarriages, single nodes, and long names.
- **Customizable Scaling**: Adjusts font size and spacing via a `scale` parameter.
- **Double-Buffered Rendering**: Ensures smooth rendering without flickering during scrolling.

## Prerequisites
- **.NET SDK**: Version 8.0 or later (for .NET WinForms). Alternatively, .NET Framework 4.8 if targeting older WinForms.
- **VSCode** (recommended) with the C# extension (`ms-dotnettools.csharp`) for development.
- **Git**: To clone the repository.
- **Windows**: Required for running WinForms applications.
- **Font**: Monaspace Neon Frozen (or fallback to Arial if unavailable).

## Installation
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-username/FamilyTree.git
   cd FamilyTree
   ```

2. **Restore Dependencies**:
   ```bash
   dotnet restore FamilyTree.csproj
   ```

3. **Build the Project**:
   ```bash
   dotnet build FamilyTree.csproj
   ```

4. **Run the Application**:
   ```bash
   dotnet run --project FamilyTree.csproj
   ```

   Alternatively, if using .NET Framework with MSBuild:
   ```bash
   msbuild FamilyTree.csproj
   .\bin\Debug\FamilyTree.exe
   ```

## Usage
1. **Launch the Application**:
   - Run the project as described above. A 500x500 window will open, displaying the family tree.
   - The default test tree is a 5-generation Western-named family (~60 individuals), including complex relationships like remarriages.

2. **Navigate the Tree**:
   - **Mouse Wheel**: Scroll vertically to view all generations.
   - **Scrollbars**: Use for precise navigation (horizontal for wide branches, vertical for depth).

3. **Test with Scaling**:
   - Modify the scale in the `Main` method to adjust font size and spacing:
     ```csharp
     Application.Run(new FamilyTree(tree, 1.5f)); // Larger View
     ```
   - Test with `0.5f` for denser layouts or `1.0f` for default.

4. **Custom Trees**:
   - Replace the default tree in `Program.cs` with your own `Tree` instance. Example structure:
     ```csharp
     Tree tree = new Tree(new Person("John Smith", Person.Gender.Male),
         new Person("Mary Smith", Person.Gender.Female), new List<Tree>()
         {
             new Tree(new Person("Jane Doe", Person.Gender.Female),
                 new Person("Robert Brown", Person.Gender.Male), new List<Tree>()
                 {
                     new Tree(new Person("Alice Brown", Person.Gender.Female))
                 })
         });
     ```

## Project Structure
- `FamilyTree.cs`: Main WinForms application with rendering and scrolling logic.
- `Tree.cs`: Defines the `Tree` class for family tree structure.
- `Person.cs`: Defines the `Person` class with name and gender.
- `FamilyTree.csproj`: Project file for building and dependencies.
- `FamilyTree.sln`: Solution file (optional, for Visual Studio users).
- `LICENSE`: MIT License file.
- `.gitignore`: Ignores build artifacts (`bin/`, `obj/`), VSCode settings, etc.

## Testing
The included 5-generation family tree (in `Program.cs`) tests:
- **Rendering**: Long names (e.g., "Christopher Lee Stone"), multiple generations.
- **Scrolling**: Vertical depth (5 generations, ~250px+ with `yOffset=50`) and horizontal width (long names, `xOffset=50`).
- **Edge Cases**: Remarriages, single individuals, and varied family sizes.
- **Performance**: Smooth rendering with ~60 nodes.

To test:
1. Run with default tree.
2. Scroll to the 5th generation (e.g., "Lily Thompson").
3. Verify remarriage rendering (e.g., "Frederick Thompson" with two spouses).
4. Test with `scale=1.5f` or `0.5f` for layout robustness.

## Contributing
Contributions are welcome! Please:
1. Fork the repository.
2. Create a feature branch (`git checkout -b feature/YourFeature`).
3. Commit changes (`git commit -m "Add YourFeature"`).
4. Push to the branch (`git push origin feature/YourFeature`).
5. Open a Pull Request.

See the [MIT License](LICENSE) for details.

## License
This project is licensed under the [MIT License](LICENSE). See the `LICENSE` file for details.

## Contact
For questions or feedback, open an issue on GitHub or contact me at gamedev.abhijit@gmail.com.

---

*Last updated: June 8, 2025*