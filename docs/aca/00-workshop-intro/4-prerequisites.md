---
title: Prerequisites
parent: Workshop Introduction
has_children: false
nav_order: 4
canonical_url: 'https://azure.github.io/aca-dotnet-workshop'
---

## Prerequisites

The workshop is divided into separate modules. Each module will guide you through building the solution code step-by-step. Ensure that you finish the modules in the right order as they have dependencies on each other.

!!! note
    Please follow these prerequisites exactly. We understand you have many choices in tooling and personal preferences. However, adhering closely to the workshop's approach increases the likelihood of your success with these labs.

Make sure you have your development environment set up and configured.

1. An Azure account with an active subscription - [Create an account for free](https://azure.microsoft.com/free/?ref=microsoft.com&utm_source=microsoft.com&utm_medium=docs&utm_campaign=visualstudio){target=_blank}
1. .NET SDK 8 or a higher version (we primarily focus on LTS versions) - [Install](https://dotnet.microsoft.com/download){target=_blank}
1. PowerShell 7.0 or higher version (For Windows Users only!) - [Install](https://learn.microsoft.com/powershell/scripting/install/installing-powershell-on-windows?view=powershell-7.4#installing-the-msi-package){target=_blank}
   > [Do not use PowerShell 5.1!](https://github.com/Azure/aca-dotnet-workshop/issues/150){target=_blank}
   > If you are unsure which version of PowerShell is running, you can execute `$PSVersionTable.PSVersion` in a PowerShell terminal.
1. On Windows, please [ensure that Hyper-V is enabled](https://learn.microsoft.com/virtualization/windowscontainers/deploy-containers/linux-containers){target=_blank} to run Linux containers in Docker.
1. Docker Desktop - [Install](https://docs.docker.com/desktop/install/windows-install/){target=_blank}
   > As of November 2024, Docker Desktop continues to be free for education purposes. Please consult the [Docker Desktop license agreement](https://docs.docker.com/subscription/desktop-license/) for any updates.
1. Visual Studio Code - [Install](https://code.visualstudio.com/){target=_blank}
1. VS Code Docker extension - [Install](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-docker){target=_blank}
1. Dapr CLI - [Install](https://docs.dapr.io/getting-started/install-dapr-cli/){target=_blank} and [Initialize](https://docs.dapr.io/getting-started/install-dapr-selfhost/){target=_blank}(`dapr init`, not `dapr init --slim`, as we need configuration and containers in place)
1. VS Code Dapr extension. Depends on Dapr CLI - [Install](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-dapr){target=_blank}
1. Azure CLI - [Install](https://docs.microsoft.com/cli/azure/install-azure-cli){target=_blank}
1. Git CLI - [Install](https://git-scm.com){target=_blank}
1. (Optional) A REST client such as [Postman](https://www.postman.com/){target=_blank} or [Insomnia](https://insomnia.rest/){target=_blank} or similar.

## Set up Git Repository & Variable Scripts

### Git Repository

This workshop typically spans several days. As such, you may close your tools, end CLI sessions, reboot, or simply want to persist working implementations in a repository as each module builds upon the one before it. A local Git repository can help.

- Open a command-line terminal and create this folder for the workshop, then switch to that folder.

    === "PowerShell"
        ```shell
        md TasksTracker.ContainerApps
        cd TasksTracker.ContainerApps
        ```
    === "Bash"
        ```shell
        mkdir TasksTracker.ContainerApps
        cd TasksTracker.ContainerApps
        export PROJECT_ROOT=$(pwd)
        ```

- Initialize the git repository.

    ```shell
    git init
    ```

- Use the `code` command to launch Visual Studio Code from that directory as shown:

    ```shell
    code .
    ```

- From VS Code's *Terminal* tab, select *New Terminal* to open a (PowerShell) terminal in the project folder *TasksTracker.ContainerApps*.

!!! note
    Throughout the documentation, we may refer to the *TasksTracker.ContainerApps* directory as *root* to keep documentation simpler.

- In the root create a `.gitignore` file. This ensures we keep our git repo clean of build assets and other artifacts.

    === ".gitignore"
        ```shell
        # Exclude build artifacts
        **/obj/
        **/bin/
        **/dist/
        ```

- Commit the `.gitignore` file.

    === "PowerShell"
        ```shell 
        git add .\.gitignore
        git commit -m "Add .gitignore"
        ```
    === "Bash"
        ```shell
        git add ./.gitignore
        git commit -m "Add .gitignore"
        ```

### Set-Variables & Variables Script

=== "PowerShell"
    - In the root create a new file called `Set-Variables.ps1`.

    - Copy the [Set-Variables.ps1 script](../../aca/30-appendix/03-variables.md){target=_blank} into the newly-created `Set-Variables.ps1` file and save it.

    - Execute the script. You will do this repeatedly throughout the modules. The output of the script will inform you how many variables are written out. As we have not yet defined any variables, the output will indicate that the script has exited (without writing out to the file). This is intentional and expected at this stage.

        ```shell
        .\Set-Variables.ps1
        ```

    - Commit the `Set-Variables.ps1` file.

        ```shell
        git add .\Set-Variables.ps1
        git commit -m "Add Set-Variables.ps1"
        ```
=== "Bash"
    - In the root create a new file called `set_variables.sh`.

    - Copy the [set_variables.sh script](../../aca/30-appendix/03-variables.md){target=_blank} into the newly-created `set_variables.sh` file and save it.

    - Make it executable and execute the script. You will do this repeatedly throughout the modules. The output of the script will inform you how many variables are written out. As we have not yet defined any variables, the output will indicate that the script has exited (without writing out to the file). This is intentional and expected at this stage.

        ```shell
        chmod +x ./set_variables.sh
        ./set_variables.sh
        ```

    - Commit the `set_variables.sh` file.

        ```shell
        git add ./set_variables.sh
        git commit -m "Add set_variables.sh"
        ```

This completes the basic setup for Git and the variables to be used. You are ready to proceed to [Module 1](../01-deploy-api-to-aca/index.md)!

## Jump Ahead

If you don't want to build the solution code from scratch, you can clone the source code repository final version by utilizing below command, and you can use the modules to deploy Azure resources using the provided Azure CLI commands.

```shell
git clone https://github.com/Azure/aca-dotnet-workshop.git
```
