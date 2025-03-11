import { ThemeProvider } from "@/components/theming/theme-provider";
import { ModeToggle } from "@/components/theming/mode-toggle";
import { GameLogin } from "@/components/game-login";

function App() {
  return (
    <ThemeProvider defaultTheme="dark" storageKey="vite-ui-theme">
      <nav className="flex justify-end p-4 w-full">
        <ModeToggle />
      </nav>
      <GameLogin />
    </ThemeProvider>
  );
}

export default App;
