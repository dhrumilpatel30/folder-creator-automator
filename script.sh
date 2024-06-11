#!/bin/zsh

SCRIPT_DIR="${0:a:h}"
CONFIG_FILE="$SCRIPT_DIR/FileMapping.conf"
TEMPLATES_DIR="$SCRIPT_DIR/Files"
DESTINATION_DIR="$(pwd)"
LOG_FILE="$SCRIPT_DIR/script_log.txt"

ARG1=$1
ARG2=$2

# Create log file if it doesn't exist
touch "$LOG_FILE"

# Function to log messages to a log file
log_message() {
    local message="$1"
    echo "$(date +"%Y-%m-%d %H:%M:%S") - $message" >> "$LOG_FILE"
}

# Check if command line arguments are provided
if [[ $# -ne 2 ]]; then
    echo "Usage: $0 <arg1> <arg2>"
    exit 1
fi

# Check if the configuration file exists
if [ ! -f "$CONFIG_FILE" ]; then
    echo "Error: Configuration file not found."
    exit 1
fi


# Iterate through each mapping in the configuration file
while IFS=: read -r pattern folder; do
    FILE_NAME=$(echo "$pattern" | sed "s/{{ARG1}}/$ARG1/g; s/{{ARG2}}/$ARG2/g")
    DEST_FOLDER=$(echo "$folder" | sed "s/{{ARG1}}/$ARG1/g; s/{{ARG2}}/$ARG2/g")
    TEMPLATE_FILE="$TEMPLATES_DIR/$pattern"
    FULL_PATH="$DESTINATION_DIR/$DEST_FOLDER/$FILE_NAME"
    
    # Create directories if they don't exist
    mkdir -p "$(dirname "$FULL_PATH")"
    
    # Check if the file already exists
    if [ -e "$FULL_PATH" ]; then
        log_message "File already exists at $FULL_PATH"
    else
        # Create the file based on the template
        sed "s/{{ARG1}}/$ARG1/g; s/{{ARG2}}/$ARG2/g" "$TEMPLATE_FILE" > "$FULL_PATH"

        log_message "File created successfully at $FULL_PATH"
    fi
done < "$CONFIG_FILE"
