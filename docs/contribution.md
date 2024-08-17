# Contribution Guidelines

## Branching Strategy

We use the [Gitflow Workflow](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow) for branching. The main branches are:

- `main`: The main branch where the source code of `HEAD` always reflects a production-ready state.
- `develop`: The main branch where the source code of `HEAD` always reflects a state with the latest delivered development changes for the next release.
- `##-issue-name`: Feature branches created from `develop` for developing new features or bug fixes. The branch name should be prefixed with the issue number and ideally, the issue name.

## Commit Messages

1. A commit message must start with a capitalized verb in the imperative mood. (e.g., Add feature, Fix bug, Update docs, etc. A good rule of thumb is to write the commit message as if saying "If applied, this commit will <commit message>").
2. If you want to provide more information about the commit, add a blank line after the commit message and write a detailed description.
3. Your commit message should not contain any whitespace errors
4. Remove unnecessary punctuation marks
5. Do not end the subject line with a period (subject line is the first line of the commit message)
6. Capitalize each paragraph
7. [Optional] Use the body to explain what changes you have made and why you made them.

## Pull Request Guidelines

1. Always create a pull request against the `develop` and `main` branches.
2. The pull request should have a descriptive title and include a summary of the changes made.
3. Pull requests should be approved by at least one reviewer before merging.
4. Never open a pull request for unfinished work. A pull request should only be opened for a complete feature or bug fix.

## Coding Style

1. File Naming
   1. Use PascalCase for file names.
   2. The file name should be the same as the class name.
2. Indentation
   1. Use 2 spaces for indentation.
3. Trailing Newline
   1. Always add a trailing newline at the end of the file.
4. Line Length
   1. Limit the number of characters per line to 120.
5. Use string interpolation
6. Use the "Allman" style for braces: open and closing brace its own new line. Braces line up with current indentation level.
7. Comments
   1. Use `//` for single-line comments.
   2. Prefer comments to be on their own line.
   3. Start comments with a lowercase letter.
   4. Don't end comments with a period.
8. Blank Lines
   1. Use a single blank line to separate logical sections of code.
   2. Don't use more than one consecutive blank line.
   3. Don't use blank lines at the start or end of a method.
9. Single Line Statements
    1. Braces must always be used, even for single-line statements.
10. Nesting
    1.  Avoid deep nesting.
    2.  Prefer early returns to deep nesting.
11. Conditions
    1.  Split complex conditions into separate variables. (e.g., `bool playerIsGrounded = m.z == floor.z && ...;`) THe compiler is smart enough to inline these.
12. `var`
   1. Prefer explicit types over 'var' keyword.
   2. Only use 'var' when the exact type is already there on the right side of the assignment.
   3. Do not use 'var' for simple types like `int`, `string`, etc.
   4. Prefer `ExampleClass instance2 = new();` over `var instance2 = new ExampleClass();`
13. Documentation
    1.  Always document your classes and public methods and properties.
    2.  Use `/** * */` for documentation comments.