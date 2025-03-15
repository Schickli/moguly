export interface Property {
  id: string;
  name: string;
  color: string;
}

export interface Player {
  id: string;
  name: string;
  balance: number;
  properties: Property[];
  isCurrentPlayer: boolean;
}

export interface LogEntry {
  id: number;
  type: "roll" | "buy" | "sell" | "trade" | "message" | "event" | "win";
  timestamp: Date;
  message: string;
  details?: string;
  players?: string[];
  amount?: number;
}