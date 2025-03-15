import { createContext, useContext, useState, useCallback } from "react";
import * as signalR from "@microsoft/signalr";

interface SignalRContextType {
  connection: signalR.HubConnection | null;
  connect: () => Promise<void>;
  disconnect: () => void;
  sendMessage: (method: string, data: any) => void;
  receivedData: any;
}

const SignalRContext = createContext<SignalRContextType | undefined>(undefined);

export const SignalRProvider = ({ children }: { children: React.ReactNode }) => {
  const [connection, setConnection] = useState<signalR.HubConnection | null>(null);
  const [receivedData, setReceivedData] = useState<any>(null);

  const connect = useCallback(async () => {
    if (connection) return;
    if(!process.env.HUB_CONNECTION_URL) return;

    const hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(process.env.HUB_CONNECTION_URL)
      .withAutomaticReconnect()
      .build();

    hubConnection.on("ReceiveMessage", (data: any) => {
      console.log("Received:", data);
      setReceivedData(data);
    });

    try {
      await hubConnection.start();
      console.log("SignalR Connected");
      setConnection(hubConnection);
    } catch (err) {
      console.error("SignalR Connection Error: ", err);
    }
  }, [connection]);

  const disconnect = useCallback(() => {
    if (connection) {
      connection.stop();
      setConnection(null);
      console.log("SignalR Disconnected");
    }
  }, [connection]);

  const sendMessage = useCallback((method: string, data: any) => {
    if (connection) {
      connection.invoke(method, data).catch(err => console.error("Send Error:", err));
    } else {
      console.warn("Cannot send message: No SignalR connection established");
    }
  }, [connection]);

  return (
    <SignalRContext.Provider value={{ connection, connect, disconnect, sendMessage, receivedData }}>
      {children}
    </SignalRContext.Provider>
  );
};

export const useSignalR = () => {
  const context = useContext(SignalRContext);
  if (!context) {
    throw new Error("useSignalR must be used within a SignalRProvider");
  }
  return context;
};