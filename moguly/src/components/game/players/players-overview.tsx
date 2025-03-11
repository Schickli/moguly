import { Button } from "@/components/ui/button";
import { ScrollArea } from "@/components/ui/scroll-area";
import { cn } from "@/lib/utils";
import { Player } from "../modals";
import { PlayerCard } from "./players-card";
import { ChevronLeft, ChevronRight, User } from "lucide-react";

interface PlayersOverviewProps {
  players: Player[];
  isCollapsed: boolean;
  setIsCollapsed: (arg0: boolean) => void;
  className?: string;
}

export function PlayersOverview({
  players,
  className,
  isCollapsed,
  setIsCollapsed,
}: PlayersOverviewProps) {
  return (
    <div className={cn("flex flex-col h-full", className)}>
      <div className="p-2 border-b bg-muted/50 flex items-center justify-between">
        {!isCollapsed && (
          <h3 className="font-semibold text-sm flex items-center gap-2">
            <User className="h-4 w-4" />
            Players
          </h3>
        )}
        <Button
          variant="ghost"
          size="icon"
          onClick={() => setIsCollapsed(!isCollapsed)}
          aria-label={
            isCollapsed ? "Expand players panel" : "Collapse players panel"
          }
        >
          {isCollapsed ? (
            <ChevronLeft className="h-4 w-4" />
          ) : (
            <ChevronRight className="h-4 w-4" />
          )}
        </Button>
      </div>
      <ScrollArea className="flex-1 overflow-auto">
        <div className="space-y-2 p-2">
          {players.map((player) => (
            <PlayerCard
              key={player.id}
              player={player}
              isCollapsed={isCollapsed}
            />
          ))}
        </div>
      </ScrollArea>
    </div>
  );
}
