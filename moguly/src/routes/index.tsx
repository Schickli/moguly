import { createFileRoute } from "@tanstack/react-router";
import { GameLogin } from "@/components/game-login";

export const Route = createFileRoute("/")({
  component: Index,
});

export function Index() {
  return <GameLogin />;
}
