import { twMerge } from "tailwind-merge";
import {
  Dice1Icon as Dice,
  ShoppingCart,
  DollarSign,
  RefreshCw,
  Clock,
  MessageSquare,
  AlertCircle,
  Trophy,
} from "lucide-react";
import { ScrollArea } from "@/components/ui/scroll-area";
import { LogEntry } from "./modals";

interface GameLogProps {
  isCollapsed: boolean;
  gameLog: LogEntry[];
  className?: string;
}

export function GameLog({ className, isCollapsed, gameLog }: GameLogProps) {
  const formatTime = (date: Date) => {
    return date.toLocaleTimeString([], { hour: "2-digit", minute: "2-digit" });
  };

  const getIcon = (type: LogEntry["type"]) => {
    switch (type) {
      case "roll":
        return <Dice className="h-4 w-4 text-purple-500" />;
      case "buy":
        return <ShoppingCart className="h-4 w-4 text-green-500" />;
      case "sell":
        return <DollarSign className="h-4 w-4 text-red-500" />;
      case "trade":
        return <RefreshCw className="h-4 w-4 text-blue-500" />;
      case "message":
        return <MessageSquare className="h-4 w-4 text-gray-500" />;
      case "event":
        return <AlertCircle className="h-4 w-4 text-amber-500" />;
      case "win":
        return <Trophy className="h-4 w-4 text-yellow-500" />;
      default:
        return <Clock className="h-4 w-4" />;
    }
  };

  const getBackgroundColor = (type: LogEntry["type"]) => {
    switch (type) {
      case "roll":
        return "bg-purple-50 dark:bg-purple-950/30";
      case "buy":
        return "bg-green-50 dark:bg-green-950/30";
      case "sell":
        return "bg-red-50 dark:bg-red-950/30";
      case "trade":
        return "bg-blue-50 dark:bg-blue-950/30";
      case "message":
        return "bg-gray-50 dark:bg-gray-800/50";
      case "event":
        return "bg-amber-50 dark:bg-amber-950/30";
      case "win":
        return "bg-yellow-50 dark:bg-yellow-950/30";
      default:
        return "";
    }
  };

  return (
    <>
      {isCollapsed ? null : (
        <div className={twMerge("border-t flex flex-col", className)}>
          <div className="p-2 border-b bg-muted/50 flex items-center justify-between">
            <h3 className="font-semibold text-sm flex items-center gap-2">
              <MessageSquare className="h-4 w-4" />
              Game Log
            </h3>
            <span className="text-xs text-muted-foreground">
              {gameLog.length} events
            </span>
          </div>

          <ScrollArea className="flex-1 h-1/3">
            <div className="p-2 space-y-1">
              {gameLog.map((log) => (
                <div
                  key={log.id}
                  className={`text-sm p-2 rounded-md ${getBackgroundColor(log.type)} transition-colors`}
                >
                  <div className="flex items-start gap-2">
                    <div className="mt-0.5">{getIcon(log.type)}</div>
                    <div className="flex-1">
                      <div className="flex justify-between items-start">
                        <span className="font-medium">{log.message}</span>
                        <span className="text-xs text-muted-foreground ml-2">
                          {formatTime(log.timestamp)}
                        </span>
                      </div>

                      {log.details && (
                        <p className="text-xs text-muted-foreground mt-1">
                          {log.details}
                        </p>
                      )}

                      {log.amount && (
                        <p
                          className={`text-xs mt-1 ${log.type === "buy" ? "text-red-600 dark:text-red-400" : "text-green-600 dark:text-green-400"}`}
                        >
                          {log.type === "buy" ? "-" : "+"} ${log.amount}
                        </p>
                      )}

                      {log.players && log.players.length > 0 && (
                        <div className="flex gap-1 mt-1">
                          {log.players.map((player, index) => (
                            <span
                              key={index}
                              className="text-xs bg-primary/10 text-primary px-1.5 py-0.5 rounded-full"
                            >
                              {player}
                            </span>
                          ))}
                        </div>
                      )}
                    </div>
                  </div>
                </div>
              ))}
            </div>
          </ScrollArea>
        </div>
      )}
    </>
  );
}
