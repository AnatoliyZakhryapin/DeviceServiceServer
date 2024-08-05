# DeviceServiceServer

## Project Description

DeviceServiceServer is a server application designed to manage communication between various IoT (Internet of Things) devices. The server uses a RESTful architecture to send and receive commands to and from connected devices. The application is built using .NET Core and offers features such as JWT-based authentication, dynamic service configuration, and a user-friendly interface for administrators and users.

## Objectives

The primary goal of the DeviceServiceServer project is to provide a scalable and secure platform for managing and controlling IoT devices via a RESTful API interface. The server is designed to facilitate communication between connected devices, allowing efficient and secure sending and receiving of commands.

## Features

The **DeviceServiceServer** project offers the following features:

- **Data Store:** Storage of data transmitted by sensors.
- **Remote Commands:** Currently, three remote commands can be executed by the service as the project is still under development:
  - **Start Service:** Starts the remote device control service.
  - **Stop Service:** Stops the remote device control service.
  - **Restart Service:** Restarts the remote device control service.

## Technologies Used

- **C# & .NET Core:** Core application logic and RESTful services.
- **NLog:** Logging framework for monitoring and recording.
- **JWT:** Secure authentication using JSON Web Tokens.
- **ASP.NET Core:** Web framework for building APIs.

## Configuration

### Device Service
- For an example of a remote control device, you can use the following device:
[DeviceService](https://github.com/AnatoliyZakhryapin/DeviceService)

### Configurazione **`appsettings.json`**
Make sure to properly configure the `appsettings.json` file for JWT authentication settings and other service configurations. Here's an example configuration:

```json
{
  "JwtSettings": {
    "Issuer": "MyDeviceServiceIssuer",
    "Audience": "MyDeviceServiceAudience",
    "SecretKey": "MyKeyPasswordDeviceService123456789!",
  }
}
```

### Explanation:

- **JwtSettings:** 
    - **Issuer:** Specifies the issuer of the JWT tokens.
    - **Audience:** Specifies the audience of the JWT tokens.
    - **SecretKey:** Secret key used to sign the JWT tokens. Must match the values on the DeviceServiceServer.

## Contributions

Contributions are welcome! Feel free to fork the project and submit a pull request with your improvements or bug fixes.

## License

This project is licensed under the MIT License.
