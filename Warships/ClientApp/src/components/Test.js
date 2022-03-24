import React, {Component, useState} from 'react';
import { HubConnectionBuilder, LogLevel, HttpTransportType } from '@microsoft/signalr';
export class Test extends Component {

    constructor(props) {
        super(props);
        this.state = {forecasts: [], loading: true,connection:null};
    }

    componentDidMount() {
        this.populateWeatherData();
    }
   
    render() {
        return (
            <div>
                <p>SIemmma</p>
            </div>
        );
    }
    async populateWeatherData() {
        try {
            console.log("Siema eniu")
            const connection = new HubConnectionBuilder()
                .withUrl("https://localhost:7019/lobby",
                    {
                        skipNegotiation: true,
                        transport: HttpTransportType.WebSockets
                    })
                .configureLogging(LogLevel.Information)
                .build();

            connection.on("ReceiveMessage", (user, message) => {
                console.log("MSG",message);
            });

            connection.on("UsersInRoom", (users) => {
                console.log("MSG",users);
            });

            connection.onclose(e => {
                console.log("PA PA PA PA");
            });

            await connection.start();
            await connection.invoke("SeekGame");
           // setConnection(connection);
        } catch (e) {
            console.log(e);
        }

    }
}