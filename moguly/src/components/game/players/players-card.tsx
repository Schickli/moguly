import { Button } from "@/components/ui/button";
import { Card, CardContent } from "@/components/ui/card";
import { cn } from "@/lib/utils";
import {
  ArrowLeftRight,
  ChevronDown,
  ChevronUp,
  Home,
  Wallet,
} from "lucide-react";
import { useState } from "react";
import { Player } from "../modals";

export function PlayerCard({
  player,
  isCollapsed,
}: {
  player: Player;
  isCollapsed: boolean;
}) {
  const [isExpanded, setIsExpanded] = useState(false);

  const handleTrade = () => {
    console.log(`Initiating trade with ${player.name}`);
    // Trade
  };

  return (
    <Card
      className={cn(
        "overflow-hidden transition-all p-0 pt-2",
        player.isCurrentPlayer && "ring-2 ring-primary/20 ring-offset-2"
      )}
    >
      <CardContent className="py-6 p-0">
        <div className="flex items-center justify-between gap-3 px-2">
          <div className="flex items-center gap-3 mb-2">
            <div
              className={cn(
                "relative flex h-10 w-10 shrink-0 items-center justify-center rounded-full bg-muted",
                player.isCurrentPlayer && "bg-primary/10"
              )}
            >
              <span className="text-lg font-medium">
                {/* Replace with color of player figure */}
                {player.name.charAt(0)}
              </span>
              {player.isCurrentPlayer && (
                <span className="absolute -right-1 -top-1 h-3 w-3 rounded-full bg-primary" />
              )}
            </div>
            {!isCollapsed && (
              <div className="flex-1 truncate">
                <h3 className="font-medium">{player.name}</h3>
                <div className="flex items-center text-sm text-muted-foreground">
                  <Wallet className="mr-1 h-3 w-3" />$
                  {player.balance.toLocaleString()}
                </div>
              </div>
            )}
          </div>

          {!isCollapsed && (
            <div className="flex items-center gap-1">
              {!player.isCurrentPlayer && (
                <Button
                  variant="ghost"
                  size="icon"
                  className="h-8 w-8"
                  onClick={() => handleTrade()}
                  aria-label={"Trade with another Player"}
                >
                  <ArrowLeftRight className="h-4 w-4" />
                </Button>
              )}
              <Button
                variant="ghost"
                size="icon"
                className="h-8 w-8"
                onClick={() => setIsExpanded(!isExpanded)}
                aria-label={
                  isExpanded
                    ? "Collapse player details"
                    : "Expand player details"
                }
              >
                {isExpanded ? (
                  <ChevronUp className="h-4 w-4" />
                ) : (
                  <ChevronDown className="h-4 w-4" />
                )}
              </Button>
            </div>
          )}
        </div>

        {!isCollapsed && isExpanded && (
          <div className="border-t px-3 py-2 bg-muted/10">
            <h4 className="text-xs font-medium text-muted-foreground mb-2">
              Player Details
            </h4>
            <div className="space-y-1 text-sm">
              <div className="flex justify-between">
                <span>Position:</span>
                <span>Boardwalk</span>
              </div>
              <div className="flex justify-between">
                <span>Get Out of Jail Cards:</span>
                <span>1</span>
              </div>
            </div>
          </div>
        )}

        {!isCollapsed && player.properties.length > 0 && (
          <div
            className={cn("border-t px-3 py-2", isExpanded && "bg-muted/10")}
          >
            <h4 className="mb-1 text-xs font-medium text-muted-foreground">
              Properties
            </h4>
            <div className="flex flex-wrap gap-1">
              {player.properties.map((property) => (
                <div
                  key={property.id}
                  className="flex items-center gap-1 rounded-sm bg-muted px-1.5 py-0.5 text-xs"
                  title={property.name}
                >
                  <div
                    className="h-2 w-2 rounded-full"
                    style={{ backgroundColor: property.color }}
                  />
                  <span className="truncate max-w-[100px]">
                    {property.name}
                  </span>
                </div>
              ))}
            </div>
          </div>
        )}

        {isCollapsed && player.properties.length > 0 && (
          <div className="border-t p-2">
            <div className="flex justify-center">
              <Home className="h-4 w-4 text-muted-foreground" />
              <span className="ml-1 text-xs">{player.properties.length}</span>
            </div>
          </div>
        )}

        {isCollapsed && isExpanded && (
          <div className="border-t p-2 bg-muted/10 text-xs">
            <div className="flex flex-col items-center gap-1">
              <div>${player.balance.toLocaleString()}</div>
              <Button
                size="icon"
                variant="ghost"
                className="h-6 w-6"
                onClick={handleTrade}
                aria-label={`Trade with ${player.name}`}
              >
                <ArrowLeftRight className="h-3 w-3" />
              </Button>
            </div>
          </div>
        )}
      </CardContent>
    </Card>
  );
}
