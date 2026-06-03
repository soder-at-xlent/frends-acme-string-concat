# Frends.Acme.StringConcat

Frends Custom Task package that concatenates strings.

## Tasks

### Concat

Concatenates an ordered list of strings, optionally joined by a separator. Null entries in the input array are treated as empty strings. Returns the resulting string on `Result.Output`.

## Build / test

```sh
dotnet build Frends.Acme.StringConcat.sln -c Release
dotnet test  Frends.Acme.StringConcat.sln -c Release
```

## Release

Releases follow a dedicated release-branch flow — see the `frends-task-release` skill or `.github/workflows/release.yml` for the mechanics. Don't bump `<Version>` in feature PRs; the release skill cuts a `release/vX.Y.Z` branch from `develop` and tags `vX.Y.Z` after the PR merges into `main`.

## License

MIT
