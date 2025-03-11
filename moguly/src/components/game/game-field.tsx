import { twMerge } from "tailwind-merge";
import { Actions } from "./actions";

interface GamefieldProps {
  className?: string;
}

export function GameField({ className }: GamefieldProps) {
  return (
    <div className={twMerge(className, "relative")}>
      <p>Gamefield Works!</p>
      <Actions className="absolute bottom-0 right-0" />
    </div>
  );
}
