import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/game/$gameId")({
  component: Game,
})

function Game() {
  const { gameId } = Route.useParams()
  return <p>Game {gameId}</p>;
}
