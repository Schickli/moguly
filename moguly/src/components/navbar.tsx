import { twMerge } from "tailwind-merge";
import { ModeToggle } from "./theming/mode-toggle";
import { Button } from "./ui/button";
import { LogOut } from "lucide-react";
import { useNavigate } from "@tanstack/react-router";

interface NavbarProps {
  gameId?: string;
  className?: string;
}

export function NavBar({ className, gameId }: NavbarProps) {
  const navigate = useNavigate();
  const handleLogOut = () => {
    // handle log out

    navigate({ to: "/" });
  };

  return (
    <nav className={twMerge(className, "justify-end flex p-4 w-full shadow")}>
      <div className="flex gap-2">
        <ModeToggle />
        {gameId && (
          <Button
            variant="outline"
            size="icon"
            className="hover:text-destructive"
            onClick={() => handleLogOut()}
          >
            <LogOut />
          </Button>
        )}
      </div>
    </nav>
  );
}
