{
  pkgs,
  lib,
  config,
  ...
}:
{
  # devenv.sh/languages/
  languages = {
    dotnet.enable = true;
    typescript.enable = true;

    javascript = {
      enable = true;
      package = pkgs.nodejs_22;
      pnpm.enable = true;
      pnpm.package = pkgs.pnpm;
    };
  };
  # devenv.sh/services/
services = {
    # devenv.sh/services/postgres/
    postgres = {
      enable = true;
      port = 5432;
      initialDatabases = [{ name = "booksite.dev"; }];
    };
 
  };
  packages = [ pkgs.omnisharp-roslyn pkgs.dotnet-ef ];
  # See full reference at https://devenv.sh/reference/options/
}
