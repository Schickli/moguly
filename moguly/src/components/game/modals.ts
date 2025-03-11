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