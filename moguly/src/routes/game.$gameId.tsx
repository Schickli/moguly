import { GameField } from "@/components/game/game-field";
import { GameLog } from "@/components/game/game-log";
import { LogEntry, Player } from "@/components/game/modals";
import { PlayersOverview } from "@/components/game/players/players-overview";
import { NavBar } from "@/components/navbar";
import { cn } from "@/lib/utils";
import { createFileRoute } from "@tanstack/react-router";
import { useState } from "react";

// Sample data for demonstration
const samplePlayers = [
  {
    id: "1",
    name: "Player 1",
    avatar: "/placeholder.svg?height=40&width=40",
    balance: 1500,
    properties: [
      { id: "p1", name: "Boardwalk", color: "#0000FF" },
      { id: "p2", name: "Park Place", color: "#0000FF" },
      { id: "p3", name: "Pennsylvania Avenue", color: "#008000" },
    ],
    isCurrentPlayer: true,
  },
  {
    id: "2",
    name: "Player 2",
    avatar: "/placeholder.svg?height=40&width=40",
    balance: 1200,
    properties: [
      { id: "p4", name: "St. James Place", color: "#FFA500" },
      { id: "p5", name: "Tennessee Avenue", color: "#FFA500" },
      { id: "p6", name: "New York Avenue", color: "#FFA500" },
    ],
    isCurrentPlayer: false,
  },
  {
    id: "3",
    name: "Player 3",
    avatar: "/placeholder.svg?height=40&width=40",
    balance: 800,
    properties: [
      { id: "p7", name: "Kentucky Avenue", color: "#FF0000" },
      { id: "p8", name: "Indiana Avenue", color: "#FF0000" },
    ],
    isCurrentPlayer: false,
  },
  {
    id: "4",
    name: "Player 4",
    avatar: "/placeholder.svg?height=40&width=40",
    balance: 2200,
    properties: [
      { id: "p9", name: "Baltic Avenue", color: "#8B4513" },
      { id: "p10", name: "Mediterranean Avenue", color: "#8B4513" },
      { id: "p11", name: "Reading Railroad", color: "#000000" },
    ],
    isCurrentPlayer: false,
  },
];

// Sample log entries for demonstration
const sampleLogs: LogEntry[] = [
  {
    id: 1,
    type: "roll",
    timestamp: new Date(Date.now() - 300000),
    message: "Player 1 rolled 6 + 4",
    details: "Moved to Boardwalk",
  },
  {
    id: 2,
    type: "buy",
    timestamp: new Date(Date.now() - 240000),
    message: "Player 1 purchased Boardwalk",
    amount: 400,
  },
  {
    id: 3,
    type: "event",
    timestamp: new Date(Date.now() - 180000),
    message: "Player 2 drew a Chance card",
    details: "Advance to GO, collect $200",
  },
  {
    id: 4,
    type: "roll",
    timestamp: new Date(Date.now() - 120000),
    message: "Player 2 rolled 3 + 2",
    details: "Moved to Oriental Avenue",
  },
  {
    id: 5,
    type: "buy",
    timestamp: new Date(Date.now() - 90000),
    message: "Player 2 purchased Oriental Avenue",
    amount: 100,
  },
  {
    id: 6,
    type: "trade",
    timestamp: new Date(Date.now() - 60000),
    message: "Player 1 traded with Player 3",
    details: "Gave: Park Place, Received: $350 + Get Out of Jail Free Card",
    players: ["Player 1", "Player 3"],
  },
  {
    id: 7,
    type: "sell",
    timestamp: new Date(Date.now() - 30000),
    message: "Player 3 sold Baltic Avenue to the bank",
    amount: 30,
  },
  {
    id: 8,
    type: "message",
    timestamp: new Date(Date.now() - 10000),
    message: "Player 4 is bankrupt!",
  },
  {
    id: 9,
    type: "win",
    timestamp: new Date(),
    message: "Player 1 wins the game!",
    details: "Total assets: $3,450",
  },
];

export const Route = createFileRoute("/game/$gameId")({
  component: Game,
});

function Game() {
  const { gameId } = Route.useParams();
  const [isCollapsed, setIsCollapsed] = useState(false);
  const [logs] = useState<LogEntry[]>(sampleLogs);
  const [players] = useState<Player[]>(samplePlayers)

  return (
    <div className="flex flex-col h-screen w-screen overflow-hidden">
      <NavBar className="" gameId={gameId} />
      <section className="flex flex-1 overflow-hidden">
        <GameField className="flex-1 overflow-auto" />

        <div
          className={cn(
            "flex flex-col border-l bg-background transition-all duration-300 overflow-hidden",
            isCollapsed ? "w-20" : "w-1/3"
          )}
        >
          <PlayersOverview
            className="flex-grow overflow-hidden h-2/3"
            players={players}
            isCollapsed={isCollapsed}
            setIsCollapsed={setIsCollapsed}
          />
          <GameLog className="h-1/3" isCollapsed={isCollapsed} gameLog={logs} />
        </div>
      </section>
    </div>
  );
}
