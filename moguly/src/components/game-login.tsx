import { useState } from "react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import {
  InputOTP,
  InputOTPGroup,
  InputOTPSlot,
} from "@/components/ui/input-otp";
import { Label } from "@/components/ui/label";
import {
  Card,
  CardContent,
  CardTitle,
  CardDescription,
  CardFooter,
  CardHeader,
} from "@/components/ui/card";
import { Plus } from "lucide-react";
import { useNavigate } from "@tanstack/react-router";
import { NavBar } from "./navbar";

export function GameLogin() {
  const [playerName, setPlayerName] = useState("");
  const [gameCode, setGameCode] = useState("");
  const navigate = useNavigate();

  const handleJoinGame = () => {
    // handle message to game

    // store name and returned playerId in localstorage in combination with gameId

    if (gameCode && playerName) {
      navigate({ to: "/game/$gameId", params: { gameId: gameCode } });
    }
  };

  const handleCreateGame = () => {
    console.log("Creating new game");
    // After creating a game, you'd typically get a gameId and navigate to it
  };

  return (
    <>
      <NavBar className="fixed"/>
      <div className="h-full flex flex-col pt-28">
        <main className="flex-1 flex items-center justify-center">
          <Card className="w-full max-w-md  backdrop-blur-sm ">
            <CardHeader>
              <CardTitle className="text-2xl font-bold">Moguly</CardTitle>
              <CardDescription>
                Play Moguly and become the biggest mogul among your friends.
              </CardDescription>
            </CardHeader>
            <CardContent className="space-y-6">
              <div className="space-y-2">
                <Label htmlFor="game-code">Game Code</Label>
                <InputOTP maxLength={6} value={gameCode} onChange={setGameCode}>
                  <InputOTPGroup>
                    {Array.from({ length: 6 }).map((_, index) => (
                      <InputOTPSlot key={index} index={index} className="" />
                    ))}
                  </InputOTPGroup>
                </InputOTP>
              </div>

              <div className="space-y-2">
                <Label htmlFor="player-name">Player Name</Label>
                <Input
                  id="player-name"
                  placeholder="Enter your name"
                  value={playerName}
                  onChange={(e) => setPlayerName(e.target.value)}
                />
              </div>

              <Button
                onClick={handleJoinGame}
                className="w-full"
                disabled={!gameCode || !playerName}
              >
                Join Game
              </Button>
            </CardContent>
            <CardFooter>
              <Button
                onClick={handleCreateGame}
                variant="outline"
                className="w-full flex items-center gap-2"
              >
                <Plus className="p-0" size={16} />
                <p> New Game</p>
              </Button>
            </CardFooter>
          </Card>
        </main>
      </div>
    </>
  );
}
