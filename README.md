# The Comprehensive Kerbal Archive Network (CKAN)

[<img src="https://img.shields.io/github/downloads/KSP-CKAN/CKAN/latest/total.svg?label=%E2%A4%93Download&style=plastic" height="48px" style="height:48px;" />](https://github.com/KSP-CKAN/CKAN/releases/latest)

[![Coverage Status](https://coveralls.io/repos/github/KSP-CKAN/CKAN/badge.svg?branch=master)](https://coveralls.io/github/KSP-CKAN/CKAN?branch=master)

[Click here to open a new CKAN issue][6]

[Click here to go to the CKAN wiki][5]

[Click here to view the CKAN metadata specification](Spec.md)

## What's the CKAN?

The CKAN is a metadata repository and associated tools to allow you to find, install, and manage mods for Kerbal Space Program.
It provides strong assurances that mods are installed in the way prescribed by their metadata files,
for the correct version of Kerbal Space Program, alongside their dependencies, and without any conflicting mods.

CKAN is great for players _and_ for authors:

- players can find new content and install it with just a few clicks;
- modders don't have to worry about misinstall problems or outdated versions;

The CKAN has been inspired by the solid and proven metadata formats from both the Debian project and the CPAN, each of which manages tens of thousands of packages.

## What's the status of the CKAN?

The CKAN is currently under [active development][1].
We very much welcome contributions, discussions, and especially pull-requests.

## The CKAN spec

At the core of the CKAN is the **[metadata specification](Spec.md)**,
which comes with a corresponding [JSON Schema](CKAN.schema) that you can also find in the [Schema Store][8]

This repository includes a validator that you can use to [validate your files][3].

## CKAN for players

CKAN can download, install and update mods in just a few clicks. See the [User guide][2] to get started with CKAN.

## CKAN for modders

While anyone can contribute metadata for your mod, we believe that you know your mod best.
So while contributors will endeavor to be as accurate as possible, we would appreciate any efforts made by mod authors to ensure our metadata's accuracy.
If the metadata we have is incorrect please [open an issue][7] and let us know.

## Contributing to CKAN

**No technical expertise is required to contribute to CKAN**

If you want to contribute, please read our [CONTRIBUTING][4] file.

## Thanks

Our sincere thanks to [SignPath.io][10] for allowing us to use their free code signing service, and to [the SignPath Foundation][11] for giving us a free code signing certificate!

---

Note: Are you looking for the Open Data portal software called CKAN? If so, their GitHub repository is found [here][9].

 [1]: https://github.com/KSP-CKAN/CKAN/commits/master
 [2]: https://github.com/KSP-CKAN/CKAN/wiki/User-guide
 [3]: https://github.com/KSP-CKAN/CKAN/wiki/Adding-a-mod-to-the-CKAN#verifying-metadata-files
 [4]: https://github.com/KSP-CKAN/.github/blob/master/CONTRIBUTING.md
 [5]: https://github.com/KSP-CKAN/CKAN/wiki
 [6]: https://github.com/KSP-CKAN/CKAN/issues/new
 [7]: https://github.com/KSP-CKAN/NetKAN/issues/new
 [8]: http://schemastore.org/json/
 [9]: https://github.com/ckan/ckan
 [10]: https://signpath.io/
 [11]: https://signpath.org/
