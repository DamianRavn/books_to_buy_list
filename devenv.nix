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
  services.postgres.enable = true;
  packages = [ pkgs.omnisharp-roslyn ];
  # See full reference at https://devenv.sh/reference/options/
}
