import { GameField } from "@/components/game/game-field";
import { GameLog } from "@/components/game/game-log";
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

export const Route = createFileRoute("/game/$gameId")({
  component: Game,
});

function Game() {
  const { gameId } = Route.useParams();
  const [isCollapsed, setIsCollapsed] = useState(false);

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
            players={samplePlayers}
            isCollapsed={isCollapsed}
            setIsCollapsed={setIsCollapsed}
          />
          <GameLog className="h-1/3" isCollapsed={isCollapsed} />
        </div>
      </section>
    </div>
  );
}
