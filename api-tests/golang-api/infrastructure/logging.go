package infrastructure

import (
	"os"

	"github.com/rs/zerolog"
)

func InitLog() zerolog.Logger {
	zerolog.SetGlobalLevel(zerolog.InfoLevel)
	log := zerolog.New(os.Stdout).With().
		Timestamp().
		Str("appName", "golang-api").
		Str("host", "localhost").
		Logger()
	return log
}
