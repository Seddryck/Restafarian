---
title: Install from Docker
tags: [installation]
---
## Prerequisites

**Docker Installed**: Ensure that Docker is installed and running on your system. You can download Docker from Docker's official site.

## Pulling the Docker Image

A pre-built Docker image is available on Docker Hub, you can pull it using the following command:

```powershell
docker pull seddryck/restafarian:latest
```

## Running Restafarian from Docker

Once you have the Docker image, you can run Restafarian using Docker in PowerShell.

### Basic Command

<sub>CMD:</sub>
```CMD
docker run --rm -v %cd%:/files restafarian -t <template-file> -s <source-file> -o <output-file>
```

<sub>PowerShell:</sub>
```powershell
docker run --rm -v ${pwd}:/files restafarian -t <template-file> -s <source-file> -o <output-file>
```

- `--rm`: Automatically removes the container after it finishes executing.
- `-v ${pwd}:/files`: Mounts the current directory (`${pwd}` in PowerShell or Bash, `%cd%` in CMD) to /files inside the Docker container, so Restafarian can access your local files.
- `-t <template-file>`: Specifies the path to the template file inside the /files directory.
- `-s <source-file>`: Specifies the path to the source file (YAML, JSON, or XML).
- `-o <output-file>`: Specifies the path to the output file that Restafarian will generate. If omitted, it will display the result on the host console.

## Updating Restafarian

To update to the latest version of Restafarian, either pull the new Docker image

```powershell
docker pull seddryck/restafarian:latest
```
