"use client";

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

export function GameLogin() {
  const [playerName, setPlayerName] = useState("");
  const [gameCode, setGameCode] = useState("");

  const handleJoinGame = () => {
    console.log("Joining game with code:", gameCode, "and name:", playerName);
  };

  const handleCreateGame = () => {
    console.log("Creating new game");
  };

  return (
    <div className="h-full flex flex-col">
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
                <InputOTPGroup className="gap-2 justify-center">
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
                className=" placeholder:text-white/50"
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
  );
}
