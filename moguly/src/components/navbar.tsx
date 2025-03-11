import { twMerge } from "tailwind-merge";
import { ModeToggle } from "./theming/mode-toggle";
import { Button } from "./ui/button";
import { LogOut } from "lucide-react";

interface NavbarProps {
  gameId?: string;
  className?: string;
}

export function NavBar({ className, gameId }: NavbarProps) {
  return (
    <nav className={twMerge(className, "justify-end flex p-4 w-full shadow")}>
      <div className="flex gap-2">
        <ModeToggle />
        {gameId && (
          <Button
            variant="outline"
            size="icon"
            className={"hover:text-destructive"}
          >
            <LogOut />
          </Button>
        )}
      </div>
    </nav>
  );
}
